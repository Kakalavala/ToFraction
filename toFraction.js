function toFraction(dec = 0) {
	let sd = dec.toString();

	if ((dec * 10) % 1 == 0) {
		let gcd = getGCD(dec * 10, 10);
		let n = (dec * 10) / gcd;
		let d = 10 / gcd;

		return `${n}/${d}`;
	}

	if (sd.indexOf('.') != -1) {
		if (sd.length - (sd.indexOf('.') + 1) > 6)
			dec = dec.toFixed(6);

		let c = dec.toString().length - (dec.toString().indexOf('.') + 1);
		let gcd = getGCD(Math.round((dec * (10 ** c)) - dec), (10 ** c) - 1);
		let n = Math.round(Math.round((dec * (10 ** c)) - dec) / gcd);
		let d = Math.round(((10 ** c) - 1) / gcd);

		return `${n}/${d}`;
	} else return dec;
}

let getGCD = function(n, d) {
	let rem = lastRem = num = (n < d) ? n : d;
	let den = (n < d) ? d : n;

	while (true) {
		lastRem = rem;
		rem = den % num;

		if (rem === 0)
			break;

		den = num;
		num = rem;
	}

	if (lastRem)
		return lastRem;
};