using CarparkTracker.Presentation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarparkTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarparkViewCell : ViewCell
	{
		public CarparkViewCell ()
		{
			InitializeComponent ();
            BindingContextChanged += CarparkViewCell_BindingContextChanged;
		}

        private void CarparkViewCell_BindingContextChanged(object sender, EventArgs e)
        {
            var bindingContext = (Carpark)BindingContext;
            bindingContext.PropertyChanged += CarparkViewCell_PropertyChanged;
            AvailableSpacesName.BackgroundColor = GetColor(( (Carpark)BindingContext ).ColorFactor);
        }

        private void CarparkViewCell_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ( e.PropertyName == nameof(Carpark.ColorFactor) )
                AvailableSpacesName.BackgroundColor = GetColor(((Carpark)BindingContext).ColorFactor);
        }

        private Color GetColor(double factor)
        {
            return Color.FromHsla(factor, 0.5, 0.5);
        }
    }
}