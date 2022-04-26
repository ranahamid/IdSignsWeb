import {AuthService} from 'aurelia-authentication';
import {inject} from 'aurelia-framework';
@inject(AuthService )

export class Profile{
	constructor(auth){
	    this.auth = auth;
	    this.profile=null;
		this.email='';
	};
	activate(){
		return this.auth.getMe()
		.then(data=>{
		    this.profile = data;
		    this.email=this.profile.Email;console.log(this.profile.Email);
		});
	}
	heading = 'Profile';

	//link(provider){
	//	return this.auth.authenticate(provider, true, null)
	//	/*.then((response)=>{
	//		console.log("auth response " + response);
	//		return this.auth.getMe();
	//	})*/
	//	.then(()=> this.auth.getMe())
	//	.then(data=>{
	//		this.profile = data;
	//	})
    //    .catch(err=>{
	//		console.log("profile failure");
	//	});
	//}
	//unlink(provider){
	//	return this.auth.unlink(provider)
	//	/*.then((response)=>{
	//		console.log("auth response " + response);
	//		return this.auth.getMe();
	//	})*/
	//	.then(()=> this.auth.getMe())
	//	.then(data=>{
	//		this.profile = data;
	//	});;
	//}
	
	firstname='';
	lastname='';

	
}
