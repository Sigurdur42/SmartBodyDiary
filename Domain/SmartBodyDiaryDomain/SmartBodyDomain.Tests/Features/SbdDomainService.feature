Feature: Tests the public interface of SbdDomainService

# Background: SbdDomainService is initialized with in-memory repository 

Scenario: Add first daily weight
    Given SbdDomainService is initialized with in-memory repository
    When The daily weight '85.8' is added on '26.08.2022'    
    Then There is only 1 weight record in the repository
    And The weight of '26.08.2022' is '85.8' 