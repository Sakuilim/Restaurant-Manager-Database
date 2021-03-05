# Restaurant-Manager-Database
Restaurant manager/database made with C#

● Manage the restaurant stock:
  ○ Add new products to stock. For example 10kg of chicken, 10 units of cola
  bottles.
  ○ Update existing stock.
  ○ Remove existing stock.
  ○ Example of data:
● Manage the restaurant menu:
  ○ Add new menu items. When the new menu item is created it is also
  necessary to add it’s needed ingredients. Recipe can have only one portion of
  product. For example:
  Chicken with fries:
  1 portion of chicken
  1 portion of potatoes
  1 portion of cabbage
  ○ Updating menu item names and needed products
  ○ Deleting menu items
  
Product list separated by space.


● Create customer orders.
  ○ Order can contain more than one menu item.
  ○ When the order is created the required products should be deducted from the
  stock.
  ○ If there are not enough products for the order. The entire order should be
  declined.
  Id Name Portion
  Count
  Unit Portion size
  1 Chicken 10 kg 0.3
  2 Potatoes 10 kg 0.3
  3 Cabbage 10 kg 0.3
  Id Name Products
  1 Chicken with fries 1 2 3

● The program should also:
  ○ Display all the stock
  ○ Display all the menu items
  ○ Display all the orders
