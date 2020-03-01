package assignment7;

import java.util.Scanner;

/**
 * This class defines a Straw object; this utilizes the TimsProduct class. On
 * top of having a name, cost and price, the straw also has a user-defined
 * quantity. The class cannot be constructed and must be created using the
 * .create() method.
 *
 * @author Mahmood Abdul-Khaliq
 */
public class Straw extends TimsProduct {

    private String name = "Straw";
    private int quantity;

    /**
     * Private constructor to ensure the user does not get access to this class.
     * They must use the .create() method instead.
     *
     * @param name the name of the straw
     * @param quantity the quantity of straws
     * @param cost the production cost of the straw
     * @param price the price of the straw
     */
    private Straw(String name, double cost, double price, int quantity) {
        super(name, cost, price);
        this.quantity = quantity;
    }

    /**
     * Method used to create a Straw object.
     *
     * @return a Straw object with user-defined variables (quantity, cost,
     * price).
     */
    public static Straw create() {
        Scanner input = new Scanner(System.in);
        System.out.println("Creating a new Straw.");
        System.out.println("Specify the quantity of straws: ");
        int tempQuantity = input.nextInt();
        System.out.println("Specify the cost of the straw: ");
        double tempCost = input.nextDouble();
        //who charges for straws?!?
        if (tempCost > 0) {
            System.out.println("Really? You're going to charge for straws? Whatever - your business, not mine.");
        }
        System.out.println("Specify the price of the straw: ");
        double tempPrice = input.nextDouble();
        return new Straw("Straw", tempCost, tempPrice, tempQuantity);
    }

    /**
     * Overrides the base toString function with appropriate content
     *
     * @return a string with listed variables inside this Straw
     */
    @Override
    public String toString() {
        return super.toString() + "\n\tType: Straw{Quantity: " + quantity + "}";
    }
}
