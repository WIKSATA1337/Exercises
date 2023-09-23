const travel = (row, col, memo = {}) => {
  const key = `${row},${col}`;

  if (key in memo) return memo[key];
  if (row == 1 && col == 1) return 1;
  if (row == 0 || col == 0) return 0;

  memo[key] = travel(row - 1, col, memo) + travel(row, col - 1, memo);

  return memo[key];
};

console.log(travel(1, 1));
console.log(travel(2, 3));
console.log(travel(3, 2));
console.log(travel(3, 3));
console.log(travel(18, 18));
