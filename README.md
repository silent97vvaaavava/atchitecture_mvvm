# Общая архитектура на базе MV* паттернов 
 
## Core 

### Enter Point
Представлена классом **GameRunner**. Данный класс ответственен за создание _GameRoot_, который запускает в свою очередь жизненные циклы конечной машины состояний. 

# CompositionRoot

## Содержание

- [Цель](#цель)
- [Как Использовать](#как-использовать)
- [Исходный Код](#исходный-код)

## Цель

В рамках архитектуры данного проекта, используется подход с корнем композиции `CompositionRoot`,
используещем `DiContainer`
для выстраивания более явного порядка вызовов компонентов приложения, а также разделения на контексты с различающимся
жизненым циклом.

Базовый класс `SceneCompositionRoot` отвечает за инициализацию под-контейнера для сцены и регистрацию зависимостей с
помощью Zenject DiContainer.

Это позволяет:

- Создавать специфичные для сцены зависимости.
- Управлять жизненным циклом объектов сцены.
- Добавить прозрачность в порядок вызовов подсистем приложения, в рамках сцены.

## Как Использовать

> [!WARNING]
> Метод `Initialize()` имеет возвращаемый тип `UniTask`, что обязывает нас в вызывающем коде использовать некоторые
> конструкции!
>
>В случае async ожидания:
> ```csharp
> await _compositionRoot.Initialize(_container);
> ```
> Или когда мы не ждём завершения инициализации и просто запускаем метод:
> ```csharp
>_compositionRoot.Initialize(_container).Forget();
>```

<details>

<summary>Простой пример</summary>

1. Создайте класс, унаследованный от `SceneCompositionRoot`.
2. Реализуйте метод `Initialize` для настройки DiContainer.
    ```csharp
   public class SomeSpecificCompositionRoot : SceneCompositionRoot
   {
   private DiContainer _sceneContainer;

       public override UniTask Initialize(DiContainer diContainer)
       {
           _sceneContainer = diContainer.CreateSubContainer();

           // Пример привязок
           _sceneContainer.Bind<SomeDependency>().AsSingle();

           return default;
       }
   }
    ```
3. Используйте `SceneInitializer` для инициализации сцены.

    ```csharp
    public class SomeGameState : IPayloadedState<string>
    {
        private readonly SceneInitializer _sceneInitializer;
    
        public SomeGameState(SceneInitializer sceneInitializer)
        {
            _sceneInitializer = sceneInitializer;
        }
    
        public void OnEnter(string sceneName)
        {
            _sceneInitializer.Initialize().Forget();
        }
    }
    ```

</details>

<details>

<summary>Пример биндинга зависимостей для GameEvents фичи</summary>

```csharp
public class GameplayCompositionRoot : SceneCompositionRoot
{
    [SerializeField] private GameEventConfig _gameEventConfig;
    [SerializeField] private ChoiceEventView _choiceEventView;
    [SerializeField] private NotifyEventView _notifyEventView;
    [SerializeField] private QuestEventView _questEventView;
    
    private GameEventService _gameEventService;
    private GameEventFactory _eventFactory;
    private DiContainer _sceneContainer;
    
    public override UniTask Initialize(DiContainer diContainer)
    {
        // Создаем под-контейнер для сцены
        _sceneContainer = diContainer.CreateSubContainer();

        // Инжектируем зависимости
        _sceneContainer.BindInstance(_choiceEventView).AsSingle();
        _sceneContainer.BindInstance(_notifyEventView).AsSingle();
        _sceneContainer.BindInstance(_questEventView).AsSingle();
        _sceneContainer.Bind<ITagDataContainer>().To<TestTagDataContainer>().AsSingle();
        _sceneContainer.Bind<RequirementFactory>().AsSingle();
        _sceneContainer.Bind<ImpactFactory>().AsSingle();
        _sceneContainer.Bind<ChoiceFactory>().AsSingle();
        _sceneContainer.Bind<StrategyFactory>().AsSingle();
        _sceneContainer.Bind<GameEventFactory>().AsSingle();
        _sceneContainer.Bind<GameEventService>().AsSingle();
        _sceneContainer.Bind<WithChoicesEventPresenter>().AsTransient();
        _sceneContainer.Bind<NotifyEventPresenter>().AsTransient();
        _sceneContainer.Bind<QuestEventPresenter>().AsTransient();

        // Разрешаем зависимости
        _eventFactory = _sceneContainer.Resolve<GameEventFactory>();
        _gameEventService = _sceneContainer.Resolve<GameEventService>();
        _choiceEventView.Construct(_sceneContainer.Resolve<WithChoicesEventPresenter>());
        _notifyEventView.Construct(_sceneContainer.Resolve<NotifyEventPresenter>());
        _questEventView.Construct(_sceneContainer.Resolve<QuestEventPresenter>());
        
        // В случае асинхронной инициализации возвращаем UniTask
        return default;
    }
}
```

</details>

## Исходный Код

<details>

<summary>SceneCompositionRoot</summary>

```csharp
public abstract class SceneCompositionRoot : MonoBehaviour
{
    public abstract UniTask Initialize(DiContainer diContainer);
}
```

</details>

<details>

<summary>SceneInitializer</summary>

```csharp
public class SceneInitializer
{
    private readonly DiContainer _diContainer;
    public SceneInitializer(DiContainer diContainer)
    {
        _diContainer = diContainer ?? throw new ArgumentNullException(nameof(diContainer));
    }
    public UniTask Initialize()
    {
        SceneCompositionRoot[] compositionRoots = Object.FindObjectsOfType<SceneCompositionRoot>();
        if (compositionRoots.Length > 1)
        {
            throw new Exception($"Scene has multiple composition roots!" +
                                " Must use only one composition root" +
                                $" roots:{string.Join(",", compositionRoots.Select(root => root.name))}");
        }
        return compositionRoots[0].Initialize(_diContainer);
    }
}
```

</details>

### Game State Machine
Конечная машина состояний, которая управляет жизненным циклом проекта.
Реализует интерфейс IGameStateMachine, который требует реализацию методов смены состояний.
Для добавления состояния необходимо использоваться метод _AddState<T>()_.

### State 
Состояния игры, которые управляют жизнью проекта в определенный момент.
Каждое состояние представляет собой класс, реализующий минимально интерфейс _IExitableState_. 
**IExitableState** является базовым интерфейсом для всех состояний.
Именно от него ведется наследование остальных интерфейсов, предоставляющие свои методы управления состоянием в зависимости от требуемых условий.
Список дочерних интерфейсов: 
+ **IState** - базовое состояние, которое реализует простую точку входа: _OnEnter()_;
+ **IAsyncState** - асинхронное состояние, которое может выполняет загрузочные моменты, производит операции работы с облачными сервисами в асинхронном режиме работы: _OnEnterAsync()_;
+ **IPayloadState** - состояние с полезной нагрузкой, например загрузка сцены, по завершению которой необходимо выполнить инициализацию данных: _OnEnter(**TPayload**)_, _**TPayload**_ - обобщение без ограничений;
+ **ILinkState** - состояние, которое реализует шину данных через ссылки и обладает большим набором методов для реализации:
   * _IEnumerator Execute()_ - выполнение корутины ожидания;
   * _void AddLink(ILink link)_ - привязка ссылки; 
   * _void RemoveLink(ILink link)_ - удаление ссылки; 
   * _void RemoveAllLinks()_ - удаление всех ссылок;
   * _bool ValidateLinks(out ILinkState nextState)_ - проверка ссылки на доступность; 
   * _void EnableLinks()_; 
   * _void DisableLinks()_;
> Note: _ILinkState_ является устаревшим, не рекомендуется для использования.
---
### WindowFsm 

**WindowFsm** является конечной машиной состояний для управления окнами на сцене.
Реализует следующие интерфейсы: 
+ _**IWindowFsm**_ - реализация методов управления окон;
+ _**IWindowResolve**_ - реализация методов для регистрации окон и их удаления.

#### IWindowFsm
1. Интерфейс требует реализацию методов:
   + _void OpenWindow(**Type window, bool inHistory**)_. Где _window_ - тип целевого окна, _inHistory_ - задает условие записи в историю.
   + _void OpenWindow(**Type window**)_. Открывает окно без записи его в историю.
   + _void CloseWindow(**Type window**)_. Закрывает окно, не извлеченного из историю.
   + _void CloseWindow()_. Закрывает последнее открытое окно и открывает предыдущее в истории, при его наличии.
   + _void ClearHistory()_. Очищает историю всех ранее открытых окон и открывает последние окно, добавляя в начало истории.

2. События связи _Window_ с _WindowFsm_
При регистрации окна в WindowFsm, его необходимо связать с обработчиками событий. Для этого интерфейс IWindowFsm предлагает реализацию двух событий: 
   * _event Action\<Type\> **Opened**_
   * _event Action\<Type\> **Closed**_
   
При регистрации окна, оно подписывается на методы обработки: 
```c#
   window.Opened += OnOpened;
   window.Closed += OnClosed;
```
Напрямую связать обработчик события не получится, поэтому для этого стоит реализовать скрытый метод, который позволит это сделать: 
```c#
private void OnOpened(Type window) => Opened?.Invoke(window);
```

#### IWindowResolve
Требует реализацию методов регистрации и удаления.
+ _void Set\<TView\>() where TView : class, IView_ - регистрирует окно в машине состояний и связывает его с обработчиками: 
```c#
    window.Opened += OnOpened;
    window.Closed += OnClosed;
```
+ _void CleanUp()_ - очищает коллекцию зарегистрированных окон, выполня при этом отвязку событий: 
```c#
  foreach (IWindow window in _windows.Values)
  {
    window.Opened -= OnOpened;
    window.Closed -= OnClosed;
  }
```

#### Window
Реализует интерфейс _IWindow_, который требует реализацию методов обработки открытия, а так же события открытия/закрытия.

---

### CompositionRoot

Входная точка на сцене. Позволяет явно разрешить зависимости между View и ViewModel (MVVM) или View и Presenter (MVP).
Реализует метод _UniTask Initialize(DiContainer container)_, где **container** - основной контейнер проекта. 

---
### Элементы MVVM: Model, ViewModel, View

В MVVM ViewModel служит связующим звеном между моделью и представлением, обеспечивая двустороннюю привязку данных. 
Это позволяет представлению автоматически обновляться при изменении состояния данных в ViewModel и наоборот, снижая количество кода,
необходимого для управления взаимодействием между этими компонентами.

#### Model 
Модель объединяет данные и бизнес-логику управления этими данными. 

#### ViewModel
Реализуется путем наследования от абстрактного класса _AbstractViewModel_, который в свою очередь реализует интерфейс _IViewModel_. 
Интерфейс _IViewModel_ требует обязательно к реализаци два **event Action** и два **метода**: 
1. _**InvokedOpen**_ - событие на которое подписывается View и срабатывает, когда открывается окно;
2. _**InvokedClose**_ - событие на которое подписывается View и срабатывает, когда закрывается окно;
3. _**InvokeOpen**_ - метод, в котором производится подготовка данных перед открытием какого-либо представления, используя _WindowFsm_: 
```c#
public override void InvokeOpen()
{
  // Prepare data 
  _windowFsm.OpenWindow(typeof(FooView), true);  
}
```
4. _**InvokeClose**_ - метод, в котором производится подготовка данных перед закрытием какого-либо представления, используя _WindowFsm_.
```c#
public override void InvokeClose()
{
  // Prepare data 
  _windowFsm.CloseWindow(typeof(FooView));  
}
```
5. _**HandleOpenedWindow(Type uiWindow)**_ - вызывается при открытии окна, проверяе является ли представление целевым 
6. _**HandleClosedWindow(Type uiWindow)**_ - вызывается при закрытии окна, проверяе является ли представление целевым
```c#
protected virtual void HandleOpenedWindow(Type uiWindow)
{
    if(Window == uiWindow)
        InvokedOpen?.Invoke();
}
```

_AbstractViewModel_ дает базовые реализации методов взаимодействия с _IWindowFsm_, а так же реализует связь между _ViewModel_ и _Model_.
ViewModel не порождает наследников MonoBehaviour, даже через фабрики или пулы. Единственная задача VM - свзять модель и представления, предварительно подготовив данные из модели для отправки в представление.

#### View

Является наследников _MonoBehaviour_ и отвечает за отображение данных и регистрацию взаимодействий с пользователем. 
Обработки данных ввода или других любых данных не происходит в представлении. 
Представление, исходя из полученных данных, способна создать или взять из пула необходимые для ее работы объекты. 

_View_ представлено двумя абстрактными классами: **_AbstractView_** и **_AbstractPayloadView\<TViewModel\>()_**. 

### Элементы MVP: Model, Presenter, View

В MVP Presenter играет центральную роль, обрабатывая пользовательский ввод, управляя логикой приложения и взаимодействуя с View и Model. 
В этом случае View является просто интерфейсом без какой-либо логики, которая может вызывать методы Presenter для выполнения действий.
