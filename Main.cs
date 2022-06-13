using System;
using System.Collections.Generic;

public class Program {
  public static int[] itemCount(string[] itemIDs){
    int[] numEach = {0, 0, 0, 0};
    foreach(string s in itemIDs){
      switch(Int32.Parse(s)){
        case 1:
          numEach[0]++;
          break;
        case 2:
          numEach[1]++;
          break;
        case 3:
          numEach[2]++;
          break;
        case 4:
          numEach[3]++;
          break;
      }
    }
    return numEach;
  }

  // Method to print out results for beakfast orders
  public static void orderBreakfast(string items){
    if (items == "") {
      Console.WriteLine("Unable to process: Main is missing, Side is Missing");
      return;
    }

    string[] breakfastItems = {"Eggs", "Toast", "Coffee"};
    // make array of item IDs in order and check how many there are of each item
    string[] itemList = items.Split(',');
    int[] numEach = itemCount(itemList);

    // check if order is invalid (missing Main or side or multiple Main)
    if (numEach[0] == 0) {
      Console.WriteLine("Unable to process: Main is missing");
      return;
    } else if (numEach[1] == 0) {
      Console.WriteLine("Unable to process: Side is missing");
      return;
    } else if (numEach[0] > 1) {
      Console.WriteLine("Unable to process: Eggs cannot be ordered more than once");
      return;
    } else if (numEach[1] > 1) {
      Console.WriteLine("Unable to process: Toast cannot be ordered more than once");
      return;
    }

    // Check if 0 or multiple coffees are ordered
    if (numEach[2] == 0) {
      breakfastItems[2] = "Water";
    } else if (numEach[2] > 1) {
      breakfastItems[2] = "Coffee(" + numEach[2] + ")";
    }

    // Print out results
    string result = breakfastItems[0] + ", " + breakfastItems[1] + ", " + breakfastItems[2];
    Console.WriteLine(result);
  }

  // Method to print out results for lunch orders
  public static void orderLunch(string items){
    if (items == "") {
      Console.WriteLine("Unable to process: Main is missing, Side is Missing");
      return;
    }

    string[] lunchItems = {"Sandwich", "Chips", "Soda"};
    // make array of item IDs in order and check how many there are of each item
    string[] itemList = items.Split(',');
    int[] numEach = itemCount(itemList);

    // check if order is invalid (missing Main or side or multiple Main)
    if (numEach[0] == 0) {
      Console.WriteLine("Unable to process: Main is missing");
      return;
    } else if (numEach[1] == 0) {
      Console.WriteLine("Unable to process: Side is missing");
      return;
    } else if (numEach[0] > 1) {
      Console.WriteLine("Unable to process: Sandwich cannot be ordered more than once");
      return;
    } else if (numEach[2] > 1) {
      Console.WriteLine("Unable to process: Soda cannot be ordered more than once");
      return;
    }

    // Check if 0 sodas are ordered or multiple chips are ordered
    if (numEach[2] == 0) {
      lunchItems[2] = "Water";
    } 
    if (numEach[1] > 1) {
      lunchItems[1] = "Chips(" + numEach[1] + ")";
    }

    // Print out results
    string result = lunchItems[0] + ", " + lunchItems[1] + ", " + lunchItems[2];
    Console.WriteLine(result);
  }

  // Method to print out results for dinner orders
  public static void orderDinner(string items){
    if (items == "") {
      Console.WriteLine("Unable to process: Main is missing, Side is Missing, Dessert is missing");
      return;
    }

    string[] dinnerItems = {"Steak", "Potatoes", "Wine", "Cake"};
    // make array of item IDs in order and check how many there are of each item
    string[] itemList = items.Split(',');
    int[] numEach = itemCount(itemList);

    // check if order is invalid (missing Main or side or multiple Main)
    if (numEach[0] == 0) {
      Console.WriteLine("Unable to process: Main is missing");
      return;
    } else if (numEach[1] == 0) {
      Console.WriteLine("Unable to process: Side is missing");
      return;
    } else if (numEach[3] == 0) {
      Console.WriteLine("Unable to process: Dessert is missing");
      return;
    } else if (numEach[0] == 0 && numEach[1] == 0) {
      Console.WriteLine("Unable to process: Main is missing, Side is Missing");
      return;
    } else if (numEach[1] == 0 && numEach[3] == 0) {
      Console.WriteLine("Unable to process: Side is missing, Dessert is Missing");
      return;
    } else if (numEach[0] == 0 && numEach[3] == 0) {
      Console.WriteLine("Unable to process: Main is missing, Dessert is Missing");
      return;
    } else if (numEach[0] > 1) {
      Console.WriteLine("Unable to process: Steak cannot be ordered more than once");
      return;
    } else if (numEach[1] > 1) {
      Console.WriteLine("Unable to process: Potatoes cannot be ordered more than once");
      return;
    } else if (numEach[2] > 1) {
      Console.WriteLine("Unable to process: Wine cannot be ordered more than once");
      return;
    } else if (numEach[3] > 1) {
      Console.WriteLine("Unable to process: Dessert cannot be ordered more than once");
      return;
    }

    // check if wine is ordered or not and adjust printed result
    string result = dinnerItems[0] + ", " + dinnerItems[1] + ", ";
    if (numEach[2] == 1) {
      result = result + dinnerItems[2] + ", ";
    }
    result = result + "Water, " + dinnerItems[3];
    Console.WriteLine(result);
  }

  public static void Main(string[] args) {
    string order = Console.ReadLine();
    string[] orderParts = order.Split(' ');

    switch(orderParts[0]){
      case "Breakfast":
        if (orderParts.Length == 1) {
          orderBreakfast("");
        } else {
          orderBreakfast(orderParts[1]);
        }
        break;
      case "Lunch":
        if (orderParts.Length == 1) {
          orderLunch("");
        } else {
          orderLunch(orderParts[1]);
        }
        break;
      case "Dinner":
        if (orderParts.Length == 1) {
          orderDinner("");
        } else {
          orderDinner(orderParts[1]);
        }
        break;
      default:
        Console.WriteLine("Invalid Order");
        break;
    }
  }
}