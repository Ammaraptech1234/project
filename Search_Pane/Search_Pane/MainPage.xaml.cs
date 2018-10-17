using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Search_Pane
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchPane.GetForCurrentView().SuggestionsRequested += SuggestionsRequested;
            SearchPane.GetForCurrentView().Show();
            SearchPane.GetForCurrentView().QuerySubmitted += QuerySubmitted;
            SearchPane.GetForCurrentView().Show();
        }

        private void QuerySubmitted(SearchPane sender, SearchPaneQuerySubmittedEventArgs args)
        {
            if (args.QueryText == "Apple")

                this.Frame.Navigate(typeof(Apple));
        }

        private void SuggestionsRequested(SearchPane sender, SearchPaneSuggestionsRequestedEventArgs args)
        {
            SearchSuggestionCollection search = args.Request.SearchSuggestionCollection;
            if (args.QueryText.StartsWith("a", StringComparison.CurrentCultureIgnoreCase))
            {

                search.AppendQuerySuggestion("Apple");
                search.AppendQuerySuggestion("Almonds");
                search.AppendQuerySuggestion("Anmimals");
            }
            else if (args.QueryText.StartsWith("b", StringComparison.CurrentCultureIgnoreCase))
            {
                search.AppendQuerySuggestion("Banana");
                search.AppendQuerySuggestion("Bat");
            }
        }

     

      
    }
}
