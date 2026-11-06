import 'package:clod_2026_programming_base/price_for.dart';
import 'package:test/test.dart';

void main() {
  group('priceFor', () {
    test("it's free for small kids", () {
      expect(
        priceFor(age: 5, isee: 0, date: .now()),
        0,
      );
    });
    test('cost 5 for poor kids on non weekends', () {
      expect(
        priceFor(age: 17, isee: 0, date: .new(2026, 10, 23)),
        5,
      );
    });
    test('cost 10 for poor adults on non weekends', () {
      expect(
        priceFor(age: 19, isee: 0, date: .new(2026, 10, 23)),
        10,
      );
    });
    test('cost more for poor kids on weekends', () {
      expect(
        priceFor(age: 17, isee: 0, date: .new(2026, 10, 24)),
        6,
      );
    });
    test('cost more for poor adults on weekends', () {
      expect(
        priceFor(age: 33, isee: 0, date: .new(2026, 10, 24)),
        12,
      );
    });
    test('cost way more for rich kids', () {
      expect(
        priceFor(age: 12, isee: 130_000, date: .new(2026, 10, 23)),
        15,
      );
    });
    test('cost way more for rich adult', () {
      expect(
        priceFor(age: 99, isee: 130_000, date: .new(2026, 10, 23)),
        30,
      );
    });
    test('cost even way more for rich kids on weekends', () {
      expect(
        priceFor(age: 12, isee: 130_000, date: .new(2026, 10, 24)),
        18,
      );
    });

    test('cost even way more for rich adulti on weekends', () {
      expect(
        priceFor(age: 99, isee: 130_000, date: .new(2026, 10, 24)),
        36,
      );
    });
  });
}
