int? max(List<int> input) {
  if (input.isEmpty) {
    return null;
  }

  var max = input.first;
  for (var number in input) {
    if (number > max) {
      max = number;
    }
  }

  return max;
}
