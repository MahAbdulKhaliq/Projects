package assignment7;

/**
 * This class defines the basis of a TimsProduct and utilizes the Commodity
 * interface. Each product has a defined name, production cost and price.
 *
 * @author Mahmood Abdul-Khaliq
 */
public class TimsProduct implements Commodity {

    private String name;
    private double cost;
    private double price;

    /**
     * Constructs a TimsProduct item.
     * 
     * @param name the name of the product
     * @param cost the production cost of the product
     * @param price the retail price of the product
     */
    public TimsProduct(String name, double cost, double price) {
        this.name = name;
        this.cost = cost;
        this.price = price;
    }

    /**
     * Returns the name of the product
     * @return the name of this TimsProduct
     */
    public String getName() {
        return name;
    }

    /**
     * Returns the production cost of this product
     * @return the cost of this TimsProduct
     */
    public double getProductionCost() {
        return cost;
    }

    /**
     * Returns the retail price of this product
     * @return the price of this TimsProduct
     */
    public double getRetailPrice() {
        return price;
    }

    /**
     * Overrides the base toString function with appropriate content
     * @return a string with listed variables inside this TimsProduct
     */
    @Override
    public String toString() {
        return "TimsProduct{Name: " + name + "\nCost: " + cost + "\nPrice: " + price + "}";
    }
}
