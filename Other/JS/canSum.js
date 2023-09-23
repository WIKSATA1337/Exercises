const canSum = (target, nums, cache = {}) => {
  if (target in cache) return cache[target];
  if (target === 0) return true;
  if (target < 0) return false;

  for (let num of nums) {
    if (canSum(target - num, nums, cache)) {
      cache[target] = true;
      return true;
    }
  }

  cache[target] = false;
  return false;
};

console.log(canSum(7, [2, 3]));
console.log(canSum(7, [5, 3, 4, 7]));
console.log(canSum(7, [2, 4]));
console.log(canSum(8, [2, 3, 5]));
console.log(canSum(300, [7, 14]));
