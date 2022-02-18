Feature: YoutubeSearchFeature
    In order to test search functionality on youtube
    As a developer
    I want to ensure functionality is working end to end

@youtubeBinding
Scenario: Youtube should search for the given keyboard and should navigate to search
    Given I have navigated to youtube website
    And I have to agree with youtube cookies
    And I have entered Selenium as youtube search keyword
    When I press the youtube search button
    Then I should be navigate to youtube search results page