Feature: YouTubeTestCase

Scenario: Extract YouTube Data
	Given Browse to "https://www.youtube.com"
	When I Search for the phrase "I will Survive-Alien song"
	And Click on the Filters button
	And Select from popup 'Video'
	And Click on the Filters button
	And Select from popup 'View count'
	And Select video "https://www.youtube.com/watch?v=ybXrrTX3LuI"
	Then User and Channel name is displayed 
	#And User can play a video  - Dont know , need help
	#And If any adverts are displayed user can play skip - dont know , need help
	And User can play more button to expand the description
	And User can extract artists name 