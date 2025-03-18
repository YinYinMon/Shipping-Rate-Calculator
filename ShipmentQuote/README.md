## Shipping Rate Calculator

## Project Overview
It contains automated UI tests for verifying the shipment quote calculation on [Pos Malaysia](https://pos.com.my/send/ratecalculator).

## Test Steps
Test Case 1: Verify user can calculate the shipment quote from Malaysia
to India.
	Step 1: User go to https://pos.com.my/send/ratecalculator
	Step 2: User enter “Malaysia” as “From” country, and enter “35600” as the
postcode.
	Step 3: User enter “India” as “To” country, and leave the postcode empty.
	Step 4: User enter 1 as the “Weight”, and user press Calculate.
	Step 5: Verify user can see multiple quotes and shipments options
available.

## Prerequisites
- Visual Studio 2022
- .NET SDK
- Google Chrome
- Chrome WebDriver (matching your Chrome version)

## Installation Steps
1. Clone the repository:
