double priceFor({
  required int age,
  required double isee,
  required DateTime date,
}) {
  double weekendFactor = switch (date) {
    DateTime(weekday: DateTime.sunday) => 1.2,
    DateTime(weekday: DateTime.saturday) => 1.2,
    _ => 1,
  };
  double richFactor = switch (isee) {
    > 100_000 => 3,
    _ => 1,
  };
  int basePrice = switch (age) {
    < 6 => 0,
    < 18 => 5,
    _ => 10,
  };
  return basePrice * richFactor * weekendFactor;
}
