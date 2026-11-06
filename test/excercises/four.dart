import 'package:test/test.dart';

void main() {
  group('sumEvenIndexesOnly', () {
    test('sums only numbers in even indexes', () {
      const list = [10, 2, 20, 3];
      expect(sumEvenIndexesOnly(list), equals(30));
    });
    test('zero on empty list', () {
      expect(sumEvenIndexesOnly([]), isZero);
    });
    test('edge case: non zero element in odd positions', () {
      expect(sumEvenIndexesOnly([0, 99999, 0, -1111]), isZero);
    });
  });
}

int sumEvenIndexesOnly(List<int> input) {
  var sum = 0;

  for (var i = 0; i < input.length; i++) {
    if (i.isEven) {
      sum = sum + input[i];
    }
  }

  return sum;
}
