export class DragDropEl{
	activate(model) {
		if (model) {
			this.name = model.name;
			this.id = model.id;
		}
	}
}