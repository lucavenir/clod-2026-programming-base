/// finds the position of the first [n] occurring in [list].
///
/// if [list] is empty, returns `null`;
/// if [n] does *not* occur into [list], returns `-1`.
int? findFirst(List<int> list, int n) {
  if (list.isEmpty) {
    return null;
  }

  for (var i = 0; i < list.length; i++) {
    final element = list[i];
    if (element == n) {
      return i;
    }
  }

  return -1;
}
