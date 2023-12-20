using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIBAProject.PageObjects;

namespace TIBAProject.StepDefinitions
{
    [Binding]
    public class YouTubeImpl 
    {
        private readonly POYouTube pOYouTube;

        public YouTubeImpl(POYouTube page)
        {
            pOYouTube = page;
        }

        [Given(@"Browse to ""(.*)""")]
        public void BrowseYouTube(string link)
        {
            pOYouTube.GoToYouTubeLink(link);
        }

        [When(@"I Search for the phrase ""(.*)""")]
        public void PhraseSearch(string phrase)
        {
            pOYouTube.SearchPhrase(phrase);
        }

        [When(@"Click on the Filters button")]
        public void ClickOnTheButton()
        {
            pOYouTube.ClickOnFilterButton();
        }

        [When(@"Select from popup '(.*)'")]
        public void SelectFromPopUp(string popUpItem)
        {
            pOYouTube.SelectItemFromFilterPopUp(popUpItem);
        }

        [When(@"Select video ""(.*)""")]
        public void SelectVideo(string video)
        {
            pOYouTube.SelectGivenVideo(video);
        }

        [Then(@"User and Channel name is displayed")]
        public void DisplayUserAndChannel()
        {
            pOYouTube.ExtractUserChannel();
        }

        [Then(@"User can play a video")]
        public void ThenUserCanPlayAVideo()
        {
            
        }

        [Then(@"If any adverts are displayed user can play skip")]
        public void ThenIfAnyAdvertsAreDisplayedUserCanPlaySkip()
        {
           
        }

        [Then(@"User can play more button to expand the description")]
        public void ThenUserCanPlayButtonToExpandTheDescription()
        {
            pOYouTube.ExtractMetaData(); 
        }

        [Then(@"User can extract artists name")]
        public void ThenUserCanExtractArtistsName()
        {
            
        }

    }
}
