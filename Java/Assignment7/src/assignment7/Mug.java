package assignment7;

import javafx.scene.Color;
import java.util.Scanner;

/**
 * This class defines a Mug object; this utilizes the TimsProduct class. On top
 * of having a name, cost and price, the mug also has a user-defined color. The
 * class cannot be constructed and must be created using the .create() method.
 *
 * @author Mahmood Abdul-Khaliq
 */
public class Mug extends TimsProduct {

    private Color color;

    /**
     * Private constructor to ensure the user does not get access to this class.
     * They must use the .create() method instead.
     *
     * @param name the name of the mug
     * @param color the color of the mug
     * @param cost the production cost of the mug
     * @param price the price of the mug
     */
    private Mug(String name, Color color, double cost, double price) {
        super(name, cost, price);
        this.color = color;
    }

    /**
     * Method used to create a Mug object.
     * 
     * @return a Mug object with user-defined variables (color, cost, price). 
     */
    public static Mug create() {
        Scanner input = new Scanner(System.in);
        System.out.println("Creating a new Mug.");
        System.out.println("Specify the color of the mug: ");
        Color tempColor = Color.web(input.nextLine());
        System.out.println("Specify the cost of the mug: ");
        double tempCost = input.nextDouble();
        System.out.println("Specify the price of the mug: ");
        double tempPrice = input.nextDouble();
        return new Mug("Mug", tempColor, tempCost, tempPrice);
    }

    /**
     * Method used to return the color of the Mug
     * @return the color of the Mug
     */
    public Color getColor() {
        return color;
    }

    /**
     * Overrides the base toString function with appropriate content
     *
     * @return a string with listed variables inside this Mug
     */
    @Override
    public String toString() {
        return super.toString() + "\n\tType: Mug{Color: " + color + "}";
    }
}
