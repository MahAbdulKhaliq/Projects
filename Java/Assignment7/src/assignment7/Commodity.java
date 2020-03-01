package assignment7;

/**
 * This class describes the Commodity interface. Commodity contains two abstract
 * methods: getProductionCost() and getRetailPrice(); these classes enforce the
 * implementation of retrieving the production cost and retail price of objects
 * that are defined as commodities.
 *
 * @author Mahmood Abdul-Khaliq
 */
public interface Commodity {
    /**
     * abstract method for production costs
     * @return the production cost of the object
     */
    public abstract double getProductionCost();

    /**
     * abstract method for retail price
     * @return the retail price of the object
     */
    public abstract double getRetailPrice();
}
