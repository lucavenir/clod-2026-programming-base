int? min(List<int> input) {
  if (input.isEmpty) {
    return null;
  }

  var min = input.first;
  for (var number in input) {
    if (number < min) {
      min = number;
    }
  }

  return min;
}
