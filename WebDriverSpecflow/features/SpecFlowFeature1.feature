Feature: Add product
	As a user
	I want to add new product

@mytag
Scenario: Add new product
	Given I login to "http://localhost:5000/"
	When  I click on "All Products" button
	And I click on Create New button
	And I enter values of new product "eda", "Beverages", "Lyngbysild", "12", "1", "111", "2", "1"
	And I click on Send button
	Then A product named "eda" should appear on the all product page