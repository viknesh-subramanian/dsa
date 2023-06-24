class Graph {
    constructor () {
        this.numberofNodes = 0;
        this.adjacentList = {};
    }
    
    addVertex(node) {
        if (!this.adjacentList[node]) {
            this.adjacentList[node] = [];
            this.numberofNodes++;
        }
    }

    addEdge(node1, node2) {
        if (!this.adjacentList[node1]) {
            this.addVertex(node1);
        }
        if (!this.adjacentList[node2]) {
            this.addVertex(node2);
        }
        this.adjacentList[node1].push(node2);
        this.adjacentList[node2].push(node1);
    }

    showConnections() {
        const all_nodes = Object.keys(this.adjacentList);
        for (let node of all_nodes) {
            let node_connections = this.adjacentList[node];
            let connections = "";
            let vertex;
            for (vertex of node_connections) {
                connections += vertex + " ";
            }
            console.log(node + "-->" + connections);
        }
    }
}