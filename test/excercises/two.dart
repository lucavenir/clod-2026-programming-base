import 'package:test/test.dart';

void main() {
  group('sumNonNegative', () {
    const list = [-99, 11, -2, 63, 14, 0];
    test('sums everything (skips negative values)', () {
      expect(sumNonNegative(list), equals(88));
    });
    test('empty list', () {
      expect(sumNonNegative([]), isZero);
    });
    test('only zeros or negative numbers', () {
      expect(sumNonNegative([-1, 0, 0, -99, -420]), isZero);
    });
  });
  group('multiplyPositive', () {
    const list = [11, -2, 63, 14, 0];
    test('sums everything (skips negative or zero values)', () {
      expect(multiplyPositive(list), equals(9702));
    });
    test('empty list', () {
      expect(multiplyPositive([]), equals(1));
    });
    test('only zeros or negative numbers', () {
      expect(multiplyPositive([]), equals(1));
    });
  });
}

int sumNonNegative(List<int> input) {
  var sum = 0;

  for (final element in input) {
    if (element > 0) {
      sum = sum + element;
    }
  }

  return sum;
}

int multiplyPositive(List<int> input) {
  var mul = 1;

  for (final element in input) {
    if (element > 0) {
      mul = mul * element;
    }
  }

  return mul;
}
