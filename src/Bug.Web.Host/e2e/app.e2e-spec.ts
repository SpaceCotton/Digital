import { BugTemplatePage } from './app.po';

describe('Bug App', function() {
  let page: BugTemplatePage;

  beforeEach(() => {
    page = new BugTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
