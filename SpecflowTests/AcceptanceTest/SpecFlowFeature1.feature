Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings


	Scenario Outline: Check if the user is able to edit the language
	Given I clicked on the Edit button of a Language added <language>
	When I update language <edit Language> and its level <level>
	Then that language should be edited and displayed under the lestings page
	Examples:
	| Language | Edit Lang | Edit Level |
	| Spanish  | Korean    | Basic      |

	Scenario Outline: Check if the user is able to delete the language
	Given I clicked on the delete button of a language added <language>
	Then that language should be deleted 
	Examples:
	| Languageto Delete |
	| French            |

	Scenario: Check if the user is able to add the new skills
	Given I clicked on the Skills tab under the profile page
	When I add a new skill
	Then that skill must be displayed on my listings

	Scenario: Check if the user is able to edit the new added skills
	Given I clicked on the edit button in the skills tab
	When I have changed the level and skill
	Then that skills should be updated
	
	Scenario: Check if the user is able to delete the skill
	Given I clicked on the delete button in the skills tab
	Then that skill should be deleted 

	Scenario: Check if the user is able to add the education
	Given I clicked on the Education Tab under the profile page
	When I clicked on the add new button and enterd all the details
	Then that education should be displayed on my listings

	Scenario: Check if the user is able to edit the Education
	Given I clicked on the edit button in the education tab
	When I update all the details in the education 
	Then that education should be updated

	Scenario: Check if the user is able to delete the Education
	Given I clicked on the delete button in the education tab
	Then that education should be deleted

	Scenario: Check if the user is able to add the certification 
	Given I clicked on the certifications tab in the profile page
	When I enterd all the details in the certification
	Then that certification should be displayed under my listings

	Scenario: Check if the user is able to edit the certification
	Given I clicked on the edit button in the cerifications tab
	When I edited all the details 
	Then that certification should be updated

	Scenario: Check if the user is able to delete the certification
	Given I clicked on the delete button in the certifications tab
	Then that certification should be deleted


