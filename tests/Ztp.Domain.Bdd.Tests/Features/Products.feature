Feature: Products
Managing products

    Scenario: Create valid product
        Given I have an empty product list
        When I create new product with parameters (<Name>, <Description>, <Price>, <Currency>, <Quantity>)
        Then product details are valid (<Name>, <Description>, <Price>, <Currency>, <Quantity>)
        Then product version is 1

    Examples:
      | Name           | Description          | Price | Currency | Quantity |
      | Iphone         | Smartphone by Apple  | 4599  | EUR      | 123      |
      | Ipad           | Tablet by Apple      | 3499  | EUR      | 234      |
      | Apple Watch SE | Smart watch by Apple | 2344  | EUR      | 444      |

    Scenario: Create product with negative price
        Given I have an empty product list
        When I create new product with parameters (<Name>, <Description>, <Price>, <Currency>, <Quantity>)
        Then a "NegativeAmountException" should be thrown

    Examples:
      | Name   | Description         | Price | Currency | Quantity |
      | Iphone | Smartphone by Apple | -1    | EUR      | 123      |

    Scenario: Update product with quantity 0
        Given I have product with following parameters
          | Name   | Description         | Price | Currency | Quantity |
          | Iphone | Smartphone by Apple | 100   | EUR      | 100      |
        When I update product details with following parameters
          | Name   | Description         | Price | Currency | Quantity |
          | Iphone | Smartphone by Apple | 100   | EUR      | 0        |
        Then I have unavailable product
        Then product version is 2

    Scenario: Update product
        Given I have product with following parameters
          | Name   | Description         | Price | Currency | Quantity |
          | Iphone | Smartphone by Apple | 100   | EUR      | 100      |
        When I update product details with following parameters
          | Name   | Description         | Price | Currency | Quantity |
          | Iphone | Smartphone by Apple | 300   | PLN      | 400      |
        Then product version is 2
        Then product changelog contains changes
          | Name   | Description         | Price | Currency | Quantity |
          | Iphone | Smartphone by Apple | 300   | PLN      | 400      |