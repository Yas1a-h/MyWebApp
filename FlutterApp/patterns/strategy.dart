abstract class PriceStrategy {
  double calculatePrice(double basePrice);
}

class RegularPriceStrategy implements PriceStrategy {
  @override
  double calculatePrice(double basePrice) {
    return basePrice;
  }
}


class ImplementedPriceStrategy implements PriceStrategy {
  @override
  double calculatePrice(double basePrice) {
    return basePrice * 0.9; // 10% discount
  }
}
