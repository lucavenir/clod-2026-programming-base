import 'package:clod_2026_programming_base/max.dart';

int? maxEven(List<int> input) {
  final evens = evenOnly(input);

  return max(evens);
}

List<int> evenOnly(List<int> input) {
  var evens = <int>[];
  for (final i in input) {
    if (i.isEven) {
      evens.add(i);
    }
  }
  return evens;
}
