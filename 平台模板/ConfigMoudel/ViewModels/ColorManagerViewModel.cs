using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using MaterialDesignColors.ColorManipulation; 
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GuiResourses.Extension;
using GuiResources.Extension;
namespace ConfigMoudel.ViewModels
{
    public class ColorManagerViewModel : BindableBase
    {
        public readonly PaletteHelper _paletteHelper = new PaletteHelper();
        private bool _isDarkTheme;
        private Color _primaryColor;
        private Color _primaryForegroundColor;

        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (SetProperty(ref _isDarkTheme, value))
                {
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
            }
        }
        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            MaterialDesignThemes.Wpf.Theme theme = paletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            paletteHelper.SetTheme(theme);
        }

         
      
        public ColorManagerViewModel()
        {
            ChangeHueCommand = new DelegateCommand<object?>(ChangeHue);
            ActiveScheme = ColorScheme.Primary;
        }

        private void SetPrimaryForegroundToSingleColor(Color color)
        {
            Theme theme = _paletteHelper.GetTheme();

            theme.PrimaryLight = new ColorPair(theme.PrimaryLight.Color, color);
            theme.PrimaryMid = new ColorPair(theme.PrimaryMid.Color, color);
            theme.PrimaryDark = new ColorPair(theme.PrimaryDark.Color, color);

            _paletteHelper.SetTheme(theme);
        }

        private GuiResources.Extension.ColorScheme _activeScheme;
        private Color _secondaryColor;
        private Color _secondaryForegroundColor;

        public GuiResources.Extension.ColorScheme ActiveScheme
        {
            get => _activeScheme;
            set
            {
                if (_activeScheme != value)
                {
                    
                    SetProperty(ref _activeScheme,value);
                }
            }
        }


        // Property to expose all ColorScheme enum values
        public IEnumerable<ColorScheme> AllColorSchemes
        {
            get => Enum.GetValues(typeof(ColorScheme)).Cast<ColorScheme>();
        }

        public DelegateCommand<object?> ChangeHueCommand { get; }
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
        public Color SelectedColor { get; private set; }

        private void SetSecondaryForegroundToSingleColor(Color color)
        {
            Theme theme = _paletteHelper.GetTheme();

            theme.SecondaryLight = new ColorPair(theme.SecondaryLight.Color, color);
            theme.SecondaryMid = new ColorPair(theme.SecondaryMid.Color, color);
            theme.SecondaryDark = new ColorPair(theme.SecondaryDark.Color, color);

            _paletteHelper.SetTheme(theme);
        }


        private void ChangeHue(object? obj)
        {
            var hue = (Color)obj!;

            SelectedColor = hue;
            if (ActiveScheme == ColorScheme.Primary)
            {
                _paletteHelper.ChangePrimaryColor(hue);
                _primaryColor = hue;
                _primaryForegroundColor = _paletteHelper.GetTheme().PrimaryMid.GetForegroundColor();
            }
            else if (ActiveScheme == ColorScheme.Secondary)
            {
                _paletteHelper.ChangeSecondaryColor(hue);
                _secondaryColor = hue;
                _secondaryForegroundColor = _paletteHelper.GetTheme().SecondaryMid.GetForegroundColor();
            }
            else if (ActiveScheme == ColorScheme.PrimaryForeground)
            {
                SetPrimaryForegroundToSingleColor(hue);
                _primaryForegroundColor = hue;
            }
            else if (ActiveScheme == ColorScheme.SecondaryForeground)
            {
                SetSecondaryForegroundToSingleColor(hue);
                _secondaryForegroundColor = hue;
            }
        }
    }
}
