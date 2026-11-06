import 'package:test/test.dart';

void main() {
  group('didWeMeasureThis', () {
    test('finds first occurrence', () {
      const list = [
        (h: 1, min: 30, s: 21),
        (h: 2, min: 0, s: 13),
        (h: 0, min: 0, s: 15),
      ];
      const find = (h: 0, min: 0, s: 15);

      expect(didWeMeasureThis(list, find), isTrue);
    });
    test('doesnt find shit', () {
      const list = [
        (h: 1, min: 30, s: 21),
        (h: 2, min: 0, s: 13),
        (h: 0, min: 0, s: 15),
      ];
      const find = (h: 0, min: 0, s: 14);

      expect(didWeMeasureThis(list, find), isFalse);
    });
  });
}

bool didWeMeasureThis(
  List<({int h, int min, int s})> list,
  ({int h, int min, int s}) find,
) {
  for (var element in list) {
    if (element.h == find.h && element.min == find.min && element.s == find.s) {
      return true;
    }
  }

  return false;
}
