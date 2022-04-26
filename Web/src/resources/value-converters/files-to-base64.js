export class FilesToBase64ValueConverter{
    fromView(fileArray){
        let base64File = '';
        if(!fileArray)
            return base64File;

        let file = fileArray[0];
        let reader = new FileReader();
        reader.addEventListener("load", () => {
            base64File = reader.result;
        }, false);

        if(file)
            reader.readAsDataURL(file);
        return base64File;
    }
}