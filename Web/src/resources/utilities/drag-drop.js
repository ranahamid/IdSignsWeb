export class DragDrop{
  // data-list name must match to 'arrSrc' an 'arrDest'
  // i.e data-list="arrSrc" && data-list="arrDest"
	constructor(src, dest){
		this.arrSrc = src;
		this.arrDest = dest;
	}

	itemDropped(item, target, source, sibling) {
    let theItem;
    let sourceArr;
    let targetArr;
		let siblingIndex;

    switch(source.dataset.list) {
      case 'arrSrc':
        sourceArr = this.arrSrc;
        break;
      case 'arrDest':
        sourceArr = this.arrDest;
        break;
      default:
        break;
    }

    switch (target.dataset.list) {
      case 'arrSrc':
        targetArr = this.arrSrc;
        break;
      case 'arrDest':
        targetArr = this.arrDest;
        break;
      default:
        break;
    }

    theItem = sourceArr[parseInt(item.dataset.index)];
    siblingIndex = sibling != undefined? parseInt(sibling.dataset.index) : 'end';

    sourceArr.splice(parseInt(item.dataset.index), 1);
    if(parseInt(siblingIndex) === 0){
      targetArr.unshift(theItem);
    } else if(siblingIndex === 'end'){
      targetArr.push(theItem);
    } else {
      if(source.dataset.list == target.dataset.list){
        siblingIndex--;
      }
      targetArr.splice(parseInt(siblingIndex), 0, theItem);
    }
  }
}