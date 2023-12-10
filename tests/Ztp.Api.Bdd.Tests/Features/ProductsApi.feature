Feature: ProductsApi
	Testing API for Products
	

	Scenario: Get Products
		Given the API does not require authorization,
        When I send a GET request to "/api/products",
        Then I should receive a response with status code 200,
        And the response should contain the created product details.
        


