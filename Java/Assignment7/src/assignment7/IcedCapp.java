package assignment7;

import java.util.Scanner;

/**
 * This class defines an IcedCapp object; uses the TimsProduct class and
 * Consumable interface. On top of having a name, cost and price, a IcedCapp
 * also has a description and calorie count. The class cannot be created without
 * the .create() method.
 *
 * @author Mahmood Abdul-Khaliq
 */
public class IcedCapp extends TimsProduct implements Consumable {

    private String description;
    private int calorieCount;

    /**
     * Private constructor for the IcedCapp object. The user must use the
     * .create() method instead.
     *
     * @param name the name of the IcedCapp
     * @param description the description of the IcedCapp
     * @param cost the production cost of the IcedCapp
     * @param price the retail price of the IcedCapp
     * @param calories the calories of the IcedCapp
     */
    private IcedCapp(String name, String description, double cost, double price, int calories) {
        super(name, cost, price);
        this.description = description;
        calorieCount = calories;
    }

    /**
     * Method used to create a IcedCapp object
     *
     * @return a IcedCapp object with user-defined variables (description, calorie
     * count, cost, price,)
     */
    public static IcedCapp create() {
        Scanner input = new Scanner(System.in);
        System.out.println("Creating a new Iced Cappuccino.");
        System.out.println("Specify the description of the Iced Capp: ");
        String tempDesc = input.nextLine();
        System.out.println("Enter the calories of the Iced Capp: ");
        int tempCals = input.nextInt();
        System.out.println("Specify the cost of the Iced Capp: ");
        double tempCost = input.nextDouble();
        System.out.println("Specify the price of the Iced Capp: ");
        double tempPrice = input.nextDouble();
        return new IcedCapp("Iced Capp", tempDesc, tempCost, tempPrice, tempCals);
    }

    /**
     * Method used to return the calorie count
     *
     * @return the calorie count of the IcedCapp
     */
    public int getCalorieCount() {
        return calorieCount;
    }

    /**
     * Method used to return the consumption method
     *
     * @return the consumption method of the IcedCapp
     */
    public String getConsumptionMethod() {
        return "Consumption Method: Drank";
    }

    /**
     * Method used to return the description
     *
     * @return the description of the IcedCapp
     */
    public String getDescription() {
        return description;
    }

    /**
     * Overrides the base toString function with appropriate content
     *
     * @return a string with listed variables inside this IcedCapp
     */
    @Override
    public String toString() {
        return super.toString() + "\n\tType: IcedCapp{Color: Not quite peachpuff" + "\nCalories: " + calorieCount + "\nDescription" + description + "}";
    }
}
