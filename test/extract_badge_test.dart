import 'package:clod_2026_programming_base/extract_badge.dart';
import 'package:test/test.dart';

void main() {
  group('.extractBadge', () {
    test('odd numbers translate to group B', () {
      final badge = 3;

      final (group, isBoss) = extractBadge(badge);

      expect(group, equals("B"));
    });

    test('even numbers translate to group A', () {
      final badge = 2;

      final (group, isBoss) = extractBadge(badge);

      expect(group, equals("A"));
    });

    test('even numbers divisible by 10 are bosses!', () {
      final badge = 300;

      final (group, isBoss) = extractBadge(badge);

      expect(isBoss, isTrue);
    });

    test('odd numbers can never be bosses', () {
      final badge = 301;

      final (group, isBoss) = extractBadge(badge);

      expect(group, equals("B"));
      expect(isBoss, isFalse);
    });
  });
}
