const allConstruct = (target, wordBank, cache = {}) => {
  if (target in cache) return cache[target];
  if (target === "") return [[]];

  const result = [];

  for (const word of wordBank) {
    if (target.indexOf(word) === 0) {
      const suffix = target.slice(word.length);
      const ways = allConstruct(suffix, wordBank, cache);
      const targets = ways.map((way) => [word, ...way]);
      result.push(...targets);
    }
  }

  cache[target] = result;
  return result;
};

console.log(allConstruct("abcdef", ["ab", "abc", "cd", "def", "abcd"]));
console.log(
  allConstruct("skateboard", ["bo", "rd", "ate", "t", "ska", "sk", "boar"])
);
