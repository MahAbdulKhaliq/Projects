package assignment7;

/**
 * This class describes the Consumable interface. Commodity contains two
 * abstract methods: getCalorieCount() and getConsumptionMethod(); these classes
 * enforce the implementation of retrieving the calorie count and consumption
 * method of objects that are defined as consumables.
 *
 * @author Mahmood Abdul-Khaliq
 */
public interface Consumable {

    public abstract int getCalorieCount();

    public abstract String getConsumptionMethod();
}
