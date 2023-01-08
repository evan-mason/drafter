
package com.kevy.drafter.model;

import com.fasterxml.jackson.annotation.JsonBackReference;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
@Entity
@Builder
@Table(name = "PLAYERS")
public class Player {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	
	private String name;
	
	private Long image;
	
	@JsonBackReference
	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	private Team team;
	
	public Player(String name) {
		
		this.name = name;
	}
	
	@Override public String toString(){
		
		return new String("Team: " + name);
	}


}