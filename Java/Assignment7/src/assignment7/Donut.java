package assignment7;

import java.util.Scanner;

/**
 * This class defines a Donut object; uses the TimsProduct class and Consumable
 * interface. On top of having a name, cost and price, a Donut also has a
 * description and calorie count. The class cannot be created without the
 * .create() method.
 *
 * @author Mahmood Abdul-Khaliq
 */
public class Donut extends TimsProduct implements Consumable {

    private String description;
    private int calorieCount;

    /**
     * Private constructor for the Donut object. The user must use the .create()
     * method instead.
     *
     * @param name the name of the Donut
     * @param description the description of the Donut
     * @param cost the production cost of the Donut
     * @param price the retail price of the Donut
     * @param calories the calories of the Donut
     */
    private Donut(String name, String description, double cost, double price, int calories) {
        super(name, cost, price);
        this.description = description;
        calorieCount = calories;
    }

    /**
     * Method used to create a Donut object
     *
     * @return a Donut object with user-defined variables (description, calorie
     * count, cost, price,)
     */
    public static Donut create() {
        Scanner input = new Scanner(System.in);
        System.out.println("Creating a new Donut.");
        System.out.println("Specify the description of the donut: ");
        String tempDesc = input.nextLine();
        System.out.println("Enter the calories of the donut: ");
        int tempCals = input.nextInt();
        System.out.println("Specify the cost of the mug: ");
        double tempCost = input.nextDouble();
        System.out.println("Specify the price of the mug: ");
        double tempPrice = input.nextDouble();
        return new Donut("Donut", tempDesc, tempCost, tempPrice, tempCals);
    }

    /**
     * Method used to return the calorie count
     *
     * @return the calorie count of the Donut
     */
    public int getCalorieCount() {
        return calorieCount;
    }

    /**
     * Method used to return the consumption method
     *
     * @return the consumption method of the Donut
     */
    public String getConsumptionMethod() {
        return "Consumption Method: Eaten";
    }

    /**
     * Method used to return the description
     *
     * @return the description of the Donut
     */
    public String getDescription() {
        return description;
    }

    /**
     * Overrides the base toString function with appropriate content
     *
     * @return a string with listed variables inside this Donut
     */
    @Override
    public String toString() {
        return super.toString() + "\n\tType: Donut{Calories: " + calorieCount + "\nDescription" + description + "}";
    }
}
