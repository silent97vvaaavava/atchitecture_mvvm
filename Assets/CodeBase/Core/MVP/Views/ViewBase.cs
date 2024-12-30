using System;
using Core.MVP.Presenters;
using UnityEngine;

namespace Core.MVP.Views
{
    public abstract class ViewBase : MonoBehaviour, IView
    {
        private IPresenter _presenter;

        public void Construct(IPresenter presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));

            gameObject.SetActive(false);
            OnBeforeConstruct();
            _presenter = presenter;
            OnAfterConstruct();
            gameObject.SetActive(true);
        }

        public void RemovePresenter()
        {
            if (_presenter == null)
                return;

            _presenter?.Disable();
        }

        public void Destroy() =>
            Destroy(gameObject);

        protected virtual void OnBeforeConstruct()
        {
        }

        protected virtual void OnAfterConstruct()
        {
        }

        protected virtual void OnBeforeDestroy()
        {
        }

        private void OnEnable() =>
            _presenter?.Enable();

        private void OnDisable() =>
            _presenter?.Disable();

        private void OnDestroy() =>
            OnBeforeDestroy();
    }
}