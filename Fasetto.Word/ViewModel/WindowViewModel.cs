using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    class WindowViewModel:BaseViewModel
    {
        #region Private members
        /// <summary>
        /// The window this view model controls
        /// </summary>
        Window _window;

        /// <summary>
        /// The margin around the window to allow for a drop shadow and the radius of the window
        /// </summary>
        private int _outermarginsize = 10, _windowradius = 10;
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            _window = window;

            //Listen out for the window resizing
            _window.StateChanged+=(sender, e) =>
            {
                //Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
            };
            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            //XOR Operator
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));
        }

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_window);
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        #region Commands
        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show window menu
        /// </summary>
        public ICommand MenuCommand { get; set; }
        #endregion

        #region Public Properties

        /// <summary>
        /// The radius of the window's edges
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowradius;
            }
            set
            {
                _windowradius = value;
            }
        }

        /// <summary>
        /// The radius of the window's edges
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

         /// <summary>
        /// The size of the resize border around the window. taking into account the outer margin 
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _outermarginsize;
            }
            set
            {
                _outermarginsize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The height of the caption bar
        /// </summary>
        public int CaptionHeight { get; set; } = 42;

        public GridLength TitleHeight { get { return new GridLength(CaptionHeight + ResizeBorder); } }

        #endregion
    }
}
