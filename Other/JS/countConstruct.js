const countConstruct = (target, wordBank, cache = {}) => {
  if (target in cache) return cache[target];
  if (target === "") return 1;

  let totalCount = 0;

  for (const word of wordBank) {
    if (target.indexOf(word) === 0) {
      totalCount += countConstruct(target.slice(word.length), wordBank, cache);
    }
  }

  cache[target] = totalCount;
  return totalCount;
};

console.log(countConstruct("abcdef", ["ab", "abc", "cd", "def", "abcd"]));
console.log(
  countConstruct("skateboard", ["bo", "rd", "ate", "t", "ska", "sk", "boar"])
);
console.log(
  countConstruct("enterapotentpot", ["a", "p", "ent", "enter", "ot", "o", "t"])
);
console.log(
  countConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", [
    "e",
    "ee",
    "eee",
    "eeee",
    "eeeee",
    "eeeeee",
  ])
);
