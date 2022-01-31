import React,{Component} from 'react';
import { variables } from './Variables';

type ownProps={

};

type ownState = {
    posts:PostData[] , 
    currentTItle:string, 
    currentsubtitle:string,
    postId:number
}

type PostData ={
    id: number,
    title: string,
    subtitle: string,
    description: string,
    text: string,
    adddate: string,

}

export class Post extends Component<{}, ownState>{

    constructor(pr:{}){
        super(pr);  
      
        this.state={
            posts:[], 
            currentTItle:"", 
            currentsubtitle:"",
            postId:0

        }
      
    }

    refreshList(){
        
        console.log('try get data$$$');     
        
        fetch(variables.API_URL+'Post').   
        then(response=>{
           let x= response.json();
            console.log('result local api URL: ', x);
        }).then(data=>{
            console.log(data);
        });


        fetch(variables.TEST_URL).   
        then(response=>{
           let x= response.json();
            console.log('result outside api URL: ', x);
        }).then(data=>{
            console.log(data);
        });
      
    console.log('finish get data$$$');     

    }

    componentDidMount(){
        this.refreshList();
    }

    render(){
        const{posts } = this.state;
        console.log('render post site', posts);
        if(this.state?.posts){
            let {posts} = this.state;

            return(
            
                <div>
                    <h3>This is Post page</h3>
                    <table className="table table-striped">
                        <thead>
                        <tr>
                                <th>
                                    Id
                                </th>
                         
                                <th>
                                    Title
                                </th>
                                <th>
                                    Subtitle
                                </th>
                                <th>
                                    Description
                                </th>
                                <th>
                                    Text
                                </th>
                                <th>
                                    AddDate
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                      {
                          posts.map(p=>
    
                            <tr key={p.id}>
                                <td>{p.id}</td>
                                <td>{p.title}</td>
                                <td>{p.subtitle}</td>
                                <td>{p.description}</td>
                                <td>{p.text}</td>
                                <td>{p.adddate}</td>
                                <button type="button" className='btn btn-light mr-1'>

                                </button>
                            </tr>
                            )
                      }
                        </tbody>
    
                    </table>
                </div>
            )
        } else {
            return(
            
                <div>
                    <h3>This null list</h3>
                
                </div>
            )

        }
       
    }
}

    
       

