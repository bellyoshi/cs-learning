using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using ListReactiveProperty.ViewModels;
using ListReactiveProperty.Windows;
using System.Windows.Forms;

namespace ListReactiveProperty.Utils
{
    internal class WindowDispacher
    {
        public Utils.DependencyContainer Container;

        public WindowDispacher(DependencyContainer container)
        {
            Container = container;
        }

        //特定の型のウィンドウを閉じる
        public void CloseWindow<T>() where T : System.Windows.Window
        {
            var windows = System.Windows.Application.Current.Windows.OfType<T>();
            windows.ToList().ForEach(w => w.Close());
        }
        

        public T GetWindow<T>() where T : Window, new()
        {
            var windows = System.Windows.Application.Current.Windows.OfType<T>();
            return windows.FirstOrDefault() ?? new T();
        }

        public bool ExistsWindow<T>() where T : Window
        {
            var windows = System.Windows.Application.Current.Windows.OfType<T>();
            return windows.Any();
        }





        private void ShowWindow<T>() where T : Window, new()
        {
            var window = GetWindow<T>();
            window.Show();
        }

        public void ShowSettingWindow()
        {
            if (!ExistsWindow<SettingWindow>())
            {
               InitializeSettingWindow();
            }
            ShowWindow<SettingWindow>();
        }

        public void ShowViewerWindow()
        {
            if (!ExistsWindow<ViewerWindow>())
            {
                InitializeViewerWindow();
            }
            ShowWindow<ViewerWindow>();
        }

        public void InitializeViewerWindow()
        {
            //ViewerWindowの初期化
            var window = new ViewerWindow();
            WindowDragMover mover = new(window, 10, [window]);
            WindowDragResizer resize = new(window, 10);
            WindowFullScreenManager windowFullScreenManager = GetWindowFullScreenManager(window);

            var view = new ViewerViewModel();
            view.SetWindowFullScreenManager(windowFullScreenManager);
            window.DataContext = view;
        }

        private WindowFullScreenManager GetWindowFullScreenManager(ViewerWindow window)
        {
            if (Container.hasInstance<WindowFullScreenManager>())
            {
                var windowFullScreenManager = Container.GetInstance<WindowFullScreenManager>();
                windowFullScreenManager.Window = window;
                return windowFullScreenManager;
            }
            else
            {
                WindowFullScreenManager windowFullScreenManager = new(window);
                Container.RegisterInstance<WindowFullScreenManager>(windowFullScreenManager);
                return windowFullScreenManager;
            }

        }

         void InitializeSettingWindow()
        {
            if (!Container.hasInstance<WindowFullScreenManager>())
            {
                InitializeViewerWindow();
            }
            
            //SettingWindowの初期化
            var settingWindow = new SettingWindow();
            var settingViewModel = new SettingViewModel();
            var windowFullScreenManager = Container.GetInstance<WindowFullScreenManager>();
            settingViewModel.SetWindowFullScreenManager(windowFullScreenManager);
            settingWindow.DataContext = settingViewModel;

        }




    }
}
