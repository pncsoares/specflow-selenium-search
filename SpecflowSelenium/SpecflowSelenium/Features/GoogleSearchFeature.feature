Feature: GoogleSearchFeature
    In order to test search functionality on google
    As a developer
    I want to ensure functionality is working end to end

@googleBinding
Scenario: Google should search for the given keyboard and should navigate to search
    Given I have navigated to google website
    And I have to agree with google cookies
    And I have entered Specflow as google search keyword
    When I press the google search button
    Then I should be navigate to google search results page