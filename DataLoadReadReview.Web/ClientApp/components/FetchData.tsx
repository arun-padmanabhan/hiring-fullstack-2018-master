import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';

interface FetchDataState {
    tableList: TableData[];
    loading: boolean;
}

export class FetchTableName extends React.Component<RouteComponentProps<{}>, FetchDataState> {
    constructor() {
        super();
        this.state = { tableList: [], loading: true };
        fetch('api/Getdata')
            .then(response => response.json() as Promise<TableData[]>)
            .then(data => {
                this.setState({ tableList: data, loading: false });
            });

    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderDataTable(this.state.tableList);
        return <div>
            <h1>Table Data</h1>
            <p>This component demonstrates fetching Table names from the database.</p>
            
            {contents}
        </div>;
    }
     
    private renderDataTable(tableList: TableData[]) {
        return <table className='table'>
            <thead>
                <tr>   
                    <th>Name</th>                  
                </tr>
            </thead>
            <tbody>
                {tableList.map(tbl =>
                    <tr>                       
                        <td>{tbl}</td>                      
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class TableData {   
    name: string = "";
}