package assignment7;

import java.util.Scanner;

/**
 * This class describes a TimsOrder. In this class, a user-defined array is
 * created via the .create() method and allows the user to define a customer's
 * name as well as an array of TimsProduct items. Individual TimsProduct items
 * will then be specified by the user. The .getAmountDue() method retrieves and
 * adds the total retail price of all the products in the order.
 *
 * @author Mahmood Abdul-Khaliq
 */
public class TimsOrder {

    //Initializes a Scanner named 'input'
    Scanner input = new Scanner(System.in);
    //defines a size of the array
    private int size;
    //defines the name of the customer
    private String name;
    //creates a TBD array for the order
    private TimsProduct orderArray[];

    /**
     * Private constructor for a TimsOrder; the user must use the .create()
     * method instead.
     *
     * @param name the customer's name for the order
     * @param size the size of the order
     */
    private TimsOrder(String name, int size) {
        this.name = name;
        this.size = size;
        orderArray = new TimsProduct[size];

        for (int i = 0; i < orderArray.length; i++) {
            System.out.println("Object Number " + i);
            System.out.println("What is on this order? (Choices: IcedCapp, Donut, Straw, Mug");
            String userInput = input.nextLine().toLowerCase();

            while (!(userInput.equals("icedcapp")) || !(userInput.equals("donut")) || !(userInput.equals("straw")) || !(userInput.equals("mug"))) {
                System.out.println("Invalid input.");
                System.out.println("What is on this order? (Choices: IcedCapp, Donut, Straw, Mug");
                userInput = input.nextLine().toLowerCase();
            }

            if (userInput.equals("icedcapp")) {
                orderArray[i] = IcedCapp.create();
            } else if (userInput.equals("donut")) {
                orderArray[i] = Donut.create();
            } else if (userInput.equals("straw")) {
                orderArray[i] = Straw.create();
            } else if (userInput.equals("mug")) {
                orderArray[i] = Mug.create();
            }
        }
    }

    /**
     * Creates a TimsOrder object with user-specified variables (name, size of
     * order).
     *
     * @return the TimsOrder object
     */
    public static TimsOrder create() {
        Scanner input = new Scanner(System.in);

        System.out.println("Enter the name of the customer: ");
        String name = input.nextLine();

        System.out.println("Enter the size of the order");
        int size = input.nextInt();

        return new TimsOrder(name, size);
    }

    /**
     * Returns the total retail price of all objects in the order
     *
     * @return the total amount due
     */
    public double getAmountDue() {
        double amountDue = 0;
        for (TimsProduct i : orderArray) {
            amountDue += i.getProductionCost();
        }
        return amountDue;
    }

    /**
     * Overrides the base toString function with appropriate content
     *
     * @return a string with listed variables inside this TimsOrder as well as
     * all of the order's contents.
     */
    @Override
    public String toString() {

        String orderString = "";

        for (TimsProduct i : orderArray) {
            orderString += i.toString() + "\n";
        }

        return "Order for: " + name + "\n" + orderString;
    }
}
