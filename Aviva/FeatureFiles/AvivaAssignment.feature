Feature: Aviva Assignment
	In order to showcase programming knowledge
	As an Automation Analyst
	I want to demonstrate selenium based automation

	Background: 
	Given I am on Google Search page

	@mytag1
Scenario Outline: Verify No of links appearing on Google page with right search
	
	Given I enter search <keyword>
	When I click on Search Button
	Then Search result should contain <noOfLinks> with <keyword>
	When I click on specfied <linkNo> with <keyword>
	Then I should see page with <title>

	@mytag1
	Examples: 
	| keyword   | noOfLinks | linkNo | title                                                             |
	| Aviva     | 20        | 1      | Aviva Life Insurance Co Ltd                             |
	| Capgemini | 14        | 1      | Capgemini: Consulting, Technology, Digital Transformation Services|    
	
	@mytag2
Scenario Outline: Verify No of links appearing on Google page with wrong search

	Given I enter search <keyword>
	But I click on I'm Feeling Lucky Button instead
	Then I should not see search result containing <noOfLinks> with <keyword>
	And I should not be able to click on <linkNo> with <keyword>
	Then I should see page with <title>

	@mytag2
	Examples: 
	| keyword   | noOfLinks | linkNo | title                                                             |
	| Aviva     | 20        | 1      | Aviva Life Insurance Co Ltd                             |
	| Capgemini | 14        | 1      | Capgemini: Consulting, Technology, Digital Transformation Services|    

	



