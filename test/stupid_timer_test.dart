import 'package:clod_2026_programming_base/stupid_timer.dart';
import 'package:test/test.dart';

void main() {
  group('.fixTimer', () {
    test('if input < 60, we just get seconds', () {
      final input = 3;

      final (hours, minutes, seconds) = fixTimer(input);

      expect(hours, isZero);
      expect(minutes, isZero);
      expect(seconds, equals(3));
    });

    test('if input >60 (<3600), we get minutes and seconds', () {
      final input = 63;

      final (hours, minutes, seconds) = fixTimer(input);

      expect(hours, isZero);
      expect(minutes, equals(1));
      expect(seconds, equals(3));
    });

    test('if input >3600, get everything', () {
      final input = 3661;

      final (hours, minutes, seconds) = fixTimer(input);

      expect(hours, equals(1));
      expect(minutes, equals(1));
      expect(seconds, equals(1));
    });

    test('works for minutes=0, seconds>3600', () {
      final input = 3601;

      final (hours, minutes, seconds) = fixTimer(input);

      expect(hours, equals(1));
      expect(minutes, isZero);
      expect(seconds, equals(1));
    });
  });
}
