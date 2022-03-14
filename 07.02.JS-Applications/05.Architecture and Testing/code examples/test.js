const { chromium } = require('@playwright/test');
const { expect } = require('chai');


describe('TESTS', async function () {
    this.timeout(5000);
    let page, browser;

    before(async () => {
        browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        await page.close();
    });

    it('works', async () => {
        await (new Promise(res => setTimeout(res, 2000)));
        expect(1).to.equal(1);
    });
});