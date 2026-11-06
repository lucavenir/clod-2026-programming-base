import 'package:test/test.dart';

void main() {
  const franco = [33, 4, 99, 0, -2, 4];
  group('indexing `franco`', () {
    test('[0]', () {
      expect(franco[0], equals(33));
    });
    test('[3]', () {
      expect(franco[3], equals(0));
    });
    test('[1]+[4]', () {
      expect(franco[1], equals(4));
      expect(franco[4], equals(-2));
      expect(franco[1] + franco[4], equals(2));
    });
    group('[i], where i=2', () {
      const i = 2;
      test('i', () {
        expect(franco[i], equals(99));
      });
      test('i-1', () {
        expect(franco[i - 1], equals(4));
      });
      test('i+2', () {
        expect(franco[i + 2], equals(-2));
      });
    });
  });
}
