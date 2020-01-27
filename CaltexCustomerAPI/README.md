# Caltex Servo API

This is a readme file for Caltex API to calculate points and totals for a customer purchase.

The API has only one end point which returns the response for a given request.

### Database Structure

The following tables are defined in SQl

* *tblProductDetails* - Product code and unit price.
* *tblDiscount* - DiscountID as a decimal value for the percentage, along with the product codes the discount applies for.
* *tblPromotion* - PromoCodes and the start and end dates for the promotions.
* *tblBasket* - Table to record items in the basket.
* *tblCustomerTransactions* - Record each transaction.
* *tblTotalDetail* - Record the totals.

### Solution Design

The solution has a request and response contract as defined in the Contracts folder.

The request to the StoreController goes to the StoreService, which calls the following methods.

* *EditServoData* - This saves the request details in tblCustomerTransaction, all the below methods are called from inside EditservoData and this is where the final response gets built.
* *PopulateBasket* - Foreach item in the basket we save the basket details in tblBasketData.
* *CalculatePoints, CalculateDiscount, CalculateTotal* - calculates the respective points, discount and total price for each basket item.
* *SaveTotal* - The totals are saved in tblTotalDetails.

### Sample Request

/*{ 
        "CustomerId":"8e4e8991-aaab-495b-9f24-52d5d0e519c4",
         "LoyaltyCard":"CTX0000001",
         "TransactionDate":"2020-02-06T00:00:00.000Z",
        "BasketData":
	        [
    	    {
      	    "ProductId":"PRD02",
      	    "Quantity":3,
      	    "UnitPrice": 1.3
		    }
         ]
}*/